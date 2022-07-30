import React from 'react';
import {Button, Card} from "react-bootstrap";
import classes from '../styles/Movies.css';

const MovieItem = (props) => {
    return (
        <Card className="movie-item">
            <Card.Header as="h5">{props.data.title}</Card.Header>
            <Card.Body>
                <Card.Title>Special title treatment</Card.Title>
                <Card.Text>
                    {props.data.body}
                </Card.Text>
                <Button variant="primary">Go somewhere</Button>
            </Card.Body>
        </Card>
    );
};

export default MovieItem;