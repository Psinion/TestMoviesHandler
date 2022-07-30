import {
    Container,
} from "react-bootstrap";
import MovieItem from "./MovieItem";

const MoviesTable = function(props) {
    const { movies } = props;

    return (

        <div>
            <Container>
                {movies.map(movie =>
                    <MovieItem key={movie.id} data={movie}></MovieItem>
                )}
            </Container>
        </div>
    )
}
export default MoviesTable;