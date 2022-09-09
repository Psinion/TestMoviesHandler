import React from 'react';
import {Card, ListGroup, Nav} from "react-bootstrap";
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
            {
                props.data.actors != null && props.data.actors.length > 0 &&
                <ListGroup horizontal className="list-group-flush">
                    <ListGroup.Item><b>Actors:</b></ListGroup.Item>
                    {props.data.actors.map(actor =>
                        <ListGroup.Item key={actor.id}>{actor.name + " " + actor.surname}</ListGroup.Item>
                    )}
                </ListGroup>
            }
        </Card>
    );
};

export default MovieItem;