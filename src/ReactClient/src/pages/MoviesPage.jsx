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

    return (
        <>
            <AppHeader/>
            <MoviesTable movies={movies}/>
            <AppFooter/>
        </>
    );
}

export default MoviesPage;
