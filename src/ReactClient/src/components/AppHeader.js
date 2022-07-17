import React from "react";
import {
    Button,
    Container, Form,
    Navbar,
} from "react-bootstrap";

const AppHeader = function() {
    return (
        <Navbar bg="light" expand="md">
            <Container>
                <Navbar.Brand href="#home">Movies Handler</Navbar.Brand>
                <Navbar.Collapse>
                    <Form className="d-flex">
                        <Form.Control type="text" placeholder="Type movie name" className="me-2" />
                        <Button variant="outline-success">Search</Button>
                    </Form>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    )
}
export default AppHeader;