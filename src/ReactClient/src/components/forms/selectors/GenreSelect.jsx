import React from 'react';
import {Form} from "react-bootstrap";

const GenreSelect = ({...props}) => {
    return (
        <Form.Select {...props}>
            <option value='0'>Drama</option>
            <option value='1'>History</option>
            <option value='2'>Sport</option>
            <option value='3'>Romance</option>
            <option value='4'>Fantasy</option>
            <option value='5'>Sci-fi</option>
            <option value='6'>Adventure</option>
            <option value='7'>Horror</option>
            <option value='8'>Thriller</option>
        </Form.Select>
    );
};

export default GenreSelect;