import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import {BrowserRouter, Routes, Route, Switch, Redirect} from "react-router-dom";
import MoviesPage from "./pages/MoviesPage";
import CreateMoviePage from "./pages/CreateMoviePage";

function App() {

  return (
      <BrowserRouter>
          <Routes>
              <Route path="/movies" element={<MoviesPage/>}/>
              <Route path="/create-movie" element={<CreateMoviePage/>}/>
              <Route path="*" element={<MoviesPage/>} />
          </Routes>
      </BrowserRouter>
  );
}

export default App;
