import React from 'react';
import {Button, Card} from "react-bootstrap";
import '../styles/Movies.css';

const MovieItem = (props) => {
    return (
        <Card className="movie-item">
            <Card.Header as="h5">{props.data.title}</Card.Header>
            <Card.Body>
                <Card.Text>
                    {props.data.description}
                </Card.Text>
                {/*<Card.Title>Special title treatment</Card.Title>
                <Button variant="primary">Go somewhere</Button>*/}
            </Card.Body>
        </Card>
    );
};

export default MovieItem;