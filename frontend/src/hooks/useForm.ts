import { useState } from "react";

interface FormValues {
  [key: string]: string;
}
interface FormErrors {
  [key: string]: string;
}
const useForm = (
  initialFieldValues: FormValues,
  validate: (fieldValue?: FormValues) => FormErrors,
  setCurrentId: React.Dispatch<React.SetStateAction<number>>
) => {
  const [values, setValues] = useState(initialFieldValues);
  const [errors, setErrors] = useState({}); //[1]
  const handleInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
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
