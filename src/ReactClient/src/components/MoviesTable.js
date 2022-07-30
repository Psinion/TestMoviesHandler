import {
    Button,
    Container,
} from "react-bootstrap";
import MovieItem from "./MovieItem";
import React from 'react';
import {Link} from "react-router-dom";

const MoviesTable = function(props) {
    const { movies } = props;

    return (
        <Container>
            <div style={{marginTop: '10px'}}>
                <div>
                    <Link to="/create-movie">
                        <Button variant="outline-success">Create Movie</Button>
                    </Link>
                </div>
                <div>
                    {movies.map(movie =>
                        <MovieItem key={movie.id} data={movie}></MovieItem>
                    )}
                </div>
            </div>
        </Container>
    )
}
export default MoviesTable;