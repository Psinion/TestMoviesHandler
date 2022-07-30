import React, {useEffect, useState} from "react";
import {
    Container,
} from "react-bootstrap";
import MovieItem from "./MovieItem";

const MoviesTable = function() {
    const [movies, setMovies] = useState([]);

    useEffect(() => {
            getMovies();
        }, []
    )

    function getMovies() {
        const url = 'https://localhost:7268/api/movies';

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

    return (

        <div>
            <Container>
                {movies.map(movie =>
                    <MovieItem key='movie.id' data={movie}></MovieItem>
                )}
            </Container>
        </div>
    )
}
export default MoviesTable;