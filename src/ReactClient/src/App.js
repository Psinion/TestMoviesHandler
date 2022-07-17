import React from 'react';
import AppHeader from "./components/AppHeader";
import 'bootstrap/dist/css/bootstrap.min.css';
import AppFooter from "./components/AppFooter";
import MoviesTable from "./components/MoviesTable";

function App() {

    /*useEffect(() =>
    {
        axios.get('https://localhost:7268/api/movies/')
            .then((response) =>
                console.log(response.data)
            );
    })*/

  return (
      <>
          <AppHeader/>
          <MoviesTable/>
          <AppFooter/>
      </>
  );
}

export default App;
