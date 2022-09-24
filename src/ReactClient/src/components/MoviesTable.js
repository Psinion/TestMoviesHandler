import {
    Button, Col,
    Container, Form, Row,
} from "react-bootstrap";
import MovieItem from "./MovieItem";
import React, {useState, useEffect} from 'react';
import {Link} from "react-router-dom";
import "../styles/App.css"
import Actions from "../services/actions";

const MoviesTable = function() {

    const [movies, setMovies] = useState([]);

    useEffect(() => {
            getMovies();
        }, []
    )

    function getMovies() {
        const url = Actions.API_URL_FETCH_MOVIES;

        fetch(url, {
            method: 'GET'
        })
            .then(response => response.json())
            .then(movies => {
                console.log(movies);
                setMovies(movies)
            })
            .catch(error => {
                console.log(error);
                alert(error);
            });
    }

    function deleteMovie(id) {
        fetch(Actions.API_URL_DELETE_MOVIE + id, {
            method: 'DELETE'
        })
            .catch(error => {
                console.log(error);
                alert(error);
            });

        const moviesCopy = [...movies];
        const index = moviesCopy.findIndex(movie => {
            if(movie.id === id) {
                return true;
            }
        });

        if(index !== -1) {
            moviesCopy.splice(index, 1);
            setMovies(moviesCopy);
        }
    }

    function changeMovie(id) {

    }

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
                        <div className="d-flex">
                            <Form.Control type="text" value={dynamicFilter}
                                          onChange={event => setDynamicFilter(event.target.value)}
                                          onKeyPress={event => {
                                              if(event.key === "Enter") {
                                                  filterMovies(dynamicFilter)
                                              }
                                          }}
                                          placeholder="Enter movie name" className="me-2"/>
                            <Button onClick={() => filterMovies(dynamicFilter)} variant="outline-success">Search</Button>
                        </div>
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
                        <MovieItem key={movie.id} data={movie} onDelete={deleteMovie}/>
                    )}
                </div>
            </div>
        </Container>
    )
}
export default MoviesTable;