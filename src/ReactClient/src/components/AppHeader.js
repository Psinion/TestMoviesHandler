import React from "react";
import {
    Button, Container, Form, Nav, Navbar, NavLink,
} from "react-bootstrap";
import {LinkContainer} from 'react-router-bootstrap'

const AppHeader = function() {
    return (
        <Navbar bg="light" expand="lg">
            <Container>
                <Navbar.Brand href="#home">Movies Handler</Navbar.Brand>
                <Navbar.Toggle />
                <Navbar.Collapse>
                    <Nav>
                        <LinkContainer to="/">
                            <Nav.Link>Home</Nav.Link>
                        </LinkContainer>
                    </Nav>
                </Navbar.Collapse>
                {/*<Navbar.Collapse className="justify-content-end">
                    <Form className="d-flex">
                        <Form.Control type="text" placeholder="Type movie name" className="me-2" />
                        <Button variant="outline-success">Search</Button>
                    </Form>
                </Navbar.Collapse>*/}
            </Container>
        </Navbar>
    )
}
export default AppHeader;