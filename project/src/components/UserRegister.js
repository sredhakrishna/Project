import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import './UserRegister.css';
import bgimg01 from './images/img.jpg';
import bgimg02 from './images/img.jpg';
import bgimg03 from './images/img.jpg';
import logo from './images/logo.jpg';

const UserRegister = () => {
  const images = [bgimg01, bgimg02, bgimg03];
  const [currentImageIndex, setCurrentImageIndex] = useState(0);

  useEffect(() => {
    const interval = setInterval(() => {
      setCurrentImageIndex((prevIndex) => (prevIndex + 1) % images.length);
    }, 3000);

    return () => {
      clearInterval(interval);
    };
  }, []);

  const backgroundStyle = {
    backgroundImage: `url(${images[currentImageIndex]})`,
  };

  const initialValues = {
    First_Name: '',
    Last_Name: '',
    PhoneNo: '',
    Email: '',
    password: '',
    confirmPassword: '',
  };

  const validationSchema = Yup.object({
    First_Name: Yup.string().required('First Name is required'),
    Last_Name: Yup.string().required('Last Name is required'),
    PhoneNo: Yup.string().required('Phone Number is required'),
    Email: Yup.string().required('Email is required').email('Invalid email address'),
    password: Yup.string().required('Password is required').min(8, 'Password is too short'),
    confirmPassword: Yup.string()
      .oneOf([Yup.ref('password'), null], 'Passwords must match')
      .required('Confirm Password is required'),
  });

  const handleSubmit = async (values) => {
    try {
      const response = await fetch('https://localhost:44326/api/Login_AU', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(values),
      });

      if (response.ok) {
        // Registration was successful, you can navigate to a success page or do something else
        console.log('Registration successful');
      } else {
        // Handle errors, such as invalid registration or server errors
        console.error('Registration failed');
      }
    } catch (error) {
      console.error('Error occurred during registration:', error);
    }
  };

  const navigate = useNavigate();

  return (
      <div className="register-container" style={backgroundStyle}>

      <nav>
   
       <div className="logo">
   
        <img src={logo} alt="Logo" />
   
       </div>
   
       <ul className="nav-links">
   
        <li><Link to="/">Home</Link></li>
   
        <li><Link to="#">About Us</Link></li>
   
        <li><Link to="#">Contact Us</Link></li>
      
   
       </ul>
   
      </nav>
   
      <div className="register-form">
   
       <h2>Register</h2>
   
       <Formik
   
        initialValues={initialValues}
   
        validationSchema={validationSchema}
   
        onSubmit={handleSubmit}
   
       >
   
        <Form>
   
        <div className="form-group">
  <label htmlFor="First_Name">First Name</label>
  <Field type="text" id="First_Name" name="First_Name" />
  <ErrorMessage name="First_Name" component="div" className="error-message" />
</div>
<div className="form-group">
  <label htmlFor="Last_Name">Last Name</label>
  <Field type="text" id="Last_Name" name="Last_Name" />
  <ErrorMessage name="Last_Name" component="div" className="error-message" />
</div>
<div className="form-group">
  <label htmlFor="PhoneNo">Phone Number</label>
  <Field type="text" id="PhoneNo" name="PhoneNo" />
  <ErrorMessage name="PhoneNo" component="div" className="error-message" />
</div>
<div className="form-group">
  <label htmlFor="Email">Email</label>
  <Field type="text" id="Email" name="Email" />
  <ErrorMessage name="Email" component="div" className="error-message" />
</div>

   
   
   
         <div className="form-group">
   
          <label htmlFor="password">Password</label>
   
          <Field type="password" id="password" name="password" />
   
          <ErrorMessage name="password" component="div" className="error-message" />
   
         </div>
   
         <div className="form-group">
   
          <label htmlFor="confirmPassword">Confirm Password</label>
   
          <Field type="password" id="confirmPassword" name="confirmPassword" />
   
          <ErrorMessage
   
           name="confirmPassword"
   
           component="div"
   
           className="error-message"
   
          />
   
         </div>
   
         <button type="submit" className="register-button">
   
          Register
   
         </button>
   
        </Form>
   
       </Formik>
   
       <Link
   
        to="/login"
   
        className="login-link"
   
        onClick={() => navigate('/login')}
   
       >
   
        Already have an account? Login here
   
       </Link>
   
      </div>
   
     </div>
   
    );
  
};

export default UserRegister;
