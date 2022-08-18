import {
    Button, Col,
    Container, Form, Row,
} from "react-bootstrap";
import MovieItem from "./MovieItem";
import React, {useState} from 'react';
import {Link} from "react-router-dom";
import "../styles/App.css"

const MoviesTable = function(props) {
    const { movies } = props;

    const [dynamicFilter, setDynamicFilter] = useState('')
    const [staticFilter, setStaticFilter] = useState('');

    function filterMovies(filter) {
        setStaticFilter(filter);
    }

    return (
        <Container className="content">
            <div>
                <Row>
                    <Col>
                        <Link className="" to="/create-movie">
                            <Button variant="outline-success">Create Movie</Button>
                        </Link>
                    </Col>
                    <Col>
                        <Form className="d-flex">
                            <Form.Control type="text" value={dynamicFilter} onChange={event => setDynamicFilter(event.target.value)} placeholder="Enter movie name" className="me-2" />
                            <Button onClick={() => filterMovies(dynamicFilter)} variant="outline-success">Search</Button>
                        </Form>
                    </Col>
                </Row>
                <div>
                    {movies.filter((movie) => {
                        if(staticFilter === "") {
                            return movie;
                        }
                        else if(movie.title.toLowerCase().includes(staticFilter.toLowerCase())) {
                            return movie;
                        }
                    })
                        .map(movie =>
                        <MovieItem key={movie.id} data={movie}/>
                    )}
                </div>
            </div>
        </Container>
    )
}
export default MoviesTable;