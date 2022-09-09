import {useState} from 'react';

function UseForm(getFreshModelObject) {

    const [values, setValues] = useState(getFreshModelObject);
    const [errors, setErrors] = useState({});

    const handleInputChange = e => {
        const { name, value } = e.target;
        setValues({...values, [name]: value});
    }

    return {
        values,
        setValues,
        errors,
        setErrors,
        handleInputChange
    }
}

export default UseForm;