import React, {useEffect, useState} from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import Actions from "../services/actions";
import AppHeader from "../components/AppHeader";
import MoviesTable from "../components/MoviesTable";
import AppFooter from "../components/AppFooter";

function MoviesPage() {
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

    function movieDelete(id) {
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

    return (
        <>
            <AppHeader/>
            <MoviesTable movies={movies} movieDelete={movieDelete}/>
            <AppFooter/>
        </>
    );
}

export default MoviesPage;
