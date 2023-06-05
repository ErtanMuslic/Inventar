import './App.css';
import Form from "./components/Form/Form";
import { useState } from "react";

function App() {
  const [values, setValues] = useState({
    username:"",
    email:"",
    birthday:"",
    password:"",
    confirmPassword:""
  });

  const inputs = [{
    id:1,
    name:"username",
    type:"text",
    placeholder:"Username",
    errorMessage:"User name should be 3-30 characters!",
    label:"Username",
    pattern:"^[A-Za-z0-9]{3,30}$",
    required:true
  },
  {
    id:2,
    name:"email",
    type:"email",
    placeholder:"Email",
    errorMessage:"It should be a valid email address!",
    label:"Email",
    required:true
  },
  {
    id:3,
    name:"birthday",
    type:"date",
    placeholder:"Birthday",
    errorMessage:"",
    label:"Birthday"
  },
  {
    id:4,
    name:"password",
    type:"password",
    placeholder:"Password",
    errorMessage:"Password should be 8-20 characters and include at least 1 letter, 1 number and 1 special character!",
    pattern:"^(?=.*[0-9])(?=.*[a-zA-Z])(?=.*[!@#$%^&*][a-zA-Z0-9!@#$%^&*]{8,20}$)",
    label:"Password",
    required:true
  },
  {
    id:5,
    name:"confirmPassword",
    type:"password",
    placeholder:"Confirm Password",
    errorMessage:"Passwords don't match!",
    pattern: values.password,
    label:"Confirm Password",
    required:true
  },
];



  console.log("re-rendered")

  const handleSubmit = (e)=> {
    e.preventDefault();
  };

  const onChange = (e) => {
    setValues({...values, [e.target.name]: e.target.value})
  };
console.log(values)
  return (
    <div className="app">
      <form onSubmit={handleSubmit}>
        <h1 className='register'>Register</h1>
        {inputs.map((input)=> (
        <Form key={input.id} {...input} value={values[input.name]} onChange={onChange}/>
        ))}
        
        <button className='btnSubmit'>Submit</button>
      </form>
    </div>
  );
}

export default App;
