import React, {useEffect, useState} from 'react';
import AppHeader from "../components/AppHeader";
import AppFooter from "../components/AppFooter";
import {Button, Col, Container, Form, Row, Table} from "react-bootstrap";
import "../styles/App.css"
import GenreSelect from "../components/forms/selectors/GenreSelect";
import Actions from "../services/actions";
import MovieItem from "../components/MovieItem";

const CreateMoviePage = () => {

    const [actors, setActors] = useState([]);

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


    return (
        <div>
            <AppHeader/>

            <Container className="content">
                <Form>
                    <Row>
                        <Form.Group as={Col}>
                            <Form.Label>Title</Form.Label>
                            <Form.Control placeholder="Enter title"></Form.Control>
                        </Form.Group>

                        <Form.Group as={Col}>
                            <Form.Label>Genre</Form.Label>
                            <GenreSelect></GenreSelect>
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
                                            <Button variant="outline-success">Select</Button>
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