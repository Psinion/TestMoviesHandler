import React, {useEffect, useState} from 'react';
import AppHeader from "../components/AppHeader";
import AppFooter from "../components/AppFooter";
import {Button, Col, Container, Form, Row, Table} from "react-bootstrap";
import "../styles/App.css"
import GenreSelect from "../components/forms/selectors/GenreSelect";
import Actions from "../services/actions";
import useForm from "../hooks/useForm";

const CreateMoviePage = () => {
    const initialMovieForm = Object.freeze({
        title: "",
        genre: 0,
        description: ""
    });

    const {
        values,
        setValues,
        errors,
        setErrors,
        handleInputChange
    } = useForm(initialMovieForm);

    const [actors, setActors] = useState([]);

    const [selectedActors, setSelectedActors] = useState([]);

    useEffect(() => {
            getActors();
        }, []
    )

    function getActors() {
        const url = Actions.API_URL_FETCH_ACTORS;

        fetch(url, {
            method: 'GET'
        })
            .then(response => response.json())
            .then(actors => {
                console.log(actors);
                setActors(actors)
            })
            .catch(error => {
                console.log(error);
                alert(error);
            });
    }

    function selectActor(actor) {
        if(!selectedActors.includes(actor)) {
            setSelectedActors([...selectedActors, actor]);
        }
    }

    function unselectActor(actor) {
        let list = [...selectedActors];
        let index = list.indexOf(actor);
        if(index !== -1) {
            list.splice(index, 1);
            setSelectedActors(list);
        }
    }

    const validate = () => {
        const {title, genre, description} = values;
        let temp = {};

        if(title == "") temp.title = 'Required field.'
        else if(title.length > 50) temp.title = "Title is too long."
        else temp.title = "";

        setErrors(temp);
        return Object.values(temp).every(x => x == "");
    }

    function submit(e) {
        e.preventDefault();

        if(!validate()) {
            e.stopPropagation();
            return;
        }

        let idList = [];
        selectedActors.forEach(x => {
            idList.push(x.id)
        });

        const movie = {
            title: values.title,
            description: values.description,
            genre: Number(values.genre),
            actorsId: idList
        }

        console.log(movie);

        fetch(Actions.API_URL_POST_MOVIE, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(movie)
            })
            .then(response => response.json())
            .then(requestData => {
               console.log(requestData)
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });

        setValues(initialMovieForm);
        setSelectedActors([]);
    }

    return (
        <div>
            <AppHeader/>
            <Container className="content">
                <Form noValidate onSubmit={submit}>
                    <div>
                        <Button variant="outline-success" type="submit" style={{width:"100px"}}>Submit</Button>
                    </div>
                    <Row>
                        <Form.Group as={Col}>
                            <Form.Label>Title</Form.Label>
                            <Form.Control type="text" name="title" value={values.title} placeholder="Enter title" onChange={handleInputChange} isInvalid={errors.title}/>
                            <Form.Control.Feedback type="invalid">{errors.title}</Form.Control.Feedback>
                        </Form.Group>

                        <Form.Group as={Col}>
                            <Form.Label>Genre</Form.Label>
                            <GenreSelect name="genre" value={values.genre} onChange={handleInputChange}/>
                        </Form.Group>
                    </Row>
                    <Row>
                        <Form.Group>
                            <Form.Label>Description</Form.Label>
                            <Form.Control  as="textarea" name="description" value={values.description} placeholder="Enter description" onChange={handleInputChange}/>
                        </Form.Group>
                    </Row>
                    <Row>
                        <Col>
                            <h3 className="text-center" style={{marginTop: 10}}>All actors</h3>
                            <div className="d-flex">
                                <Form.Control type="text" placeholder="Enter actor name" className="me-2" />
                                <Button variant="outline-success">Search</Button>
                            </div>
                        </Col>

                        <Col>
                            <h3 className="text-center" style={{marginTop: 10}}>Selected actors</h3>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <Table>
                                <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Surname</th>
                                    <th>Actions</th>
                                </tr>
                                </thead>
                                <tbody>
                                {actors.map(actor =>
                                    <tr key={actor.id}>
                                        <th>{actor.name}</th>
                                        <th>{actor.surname}</th>
                                        <th>
                                            <Button variant="outline-success" onClick={() => selectActor(actor)}>Select</Button>
                                        </th>
                                    </tr>
                                )}
                                </tbody>
                            </Table>
                        </Col>
                        <Col>
                            <Table>
                                <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Surname</th>
                                    <th>Actions</th>
                                </tr>
                                </thead>
                                <tbody>
                                    {selectedActors.map(actor =>
                                        <tr key={actor.id}>
                                            <th>{actor.name}</th>
                                            <th>{actor.surname}</th>
                                            <th>
                                                <Button variant="outline-success" onClick={() => unselectActor(actor)}>Unselect</Button>
                                            </th>
                                        </tr>
                                    )}
                                </tbody>
                            </Table>
                        </Col>
                    </Row>
                </Form>
            </Container>

            <AppFooter/>
        </div>
    );
};

export default CreateMoviePage;