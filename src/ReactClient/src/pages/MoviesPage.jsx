import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import AppHeader from "../components/AppHeader";
import MoviesTable from "../components/MoviesTable";
import AppFooter from "../components/AppFooter";

function MoviesPage() {
    return (
        <>
            <AppHeader/>
            <MoviesTable/>
            <AppFooter/>
        </>
    );
}

export default MoviesPage;
