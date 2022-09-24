import React from 'react';
import {Button, Card, ListGroup, Stack} from "react-bootstrap";
import '../styles/Movies.css';
import {Link} from "react-router-dom";

const MovieItem = ({data, onDelete}) => {

    return (
        <Card className="movie-item">
            <Card.Header as="h5">{data.title}</Card.Header>
            {
                data.description.length > 0 &&
                <Card.Body>
                    <Card.Text>
                        {data.description}
                    </Card.Text>
                </Card.Body>
            }
            {
                data.actors != null && data.actors.length > 0 &&
                <ListGroup horizontal className="list-group-flush">
                    <ListGroup.Item><b>Actors:</b></ListGroup.Item>
                    {data.actors.map(actor =>
                        <ListGroup.Item key={actor.id}>{actor.name + " " + actor.surname}</ListGroup.Item>
                    )}
                </ListGroup>
            }
            <Card.Body>
                <Stack direction="horizontal" gap="2">
                    <Link className="" to={"/change-movie/" + data.id}>
                        <Button variant="primary">Change</Button>
                    </Link>
                    <Button variant="primary" onClick={() => onDelete(data.id)}>Remove</Button>
                </Stack>
            </Card.Body>
        </Card>
    );
};

export default MovieItem;