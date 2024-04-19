import { useState } from "react";

const useForm = (initialFieldValues, validate, setCurrentId) => {
  const [values, setValues] = useState(initialFieldValues);
  const [errors, setErrors] = useState({}); //[1]
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    const fieldValue = { [name]: value };
    setValues({
      ...values,
      ...fieldValue,
    });
    validate();
  };
  const resetForm = () => {
    setValues({ ...initialFieldValues });
    setErrors({});
    setCurrentId(0);
  };
  return { values, setValues, errors, setErrors, handleInputChange, resetForm };
};

export default useForm;
