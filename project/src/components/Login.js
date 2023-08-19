import React, { useState, useEffect } from 'react';

import { Link } from 'react-router-dom';

import { Formik, Form, Field, ErrorMessage } from 'formik';

import * as Yup from 'yup';

import './Login.css';

import bgimg01 from './images/img.jpg';

import bgimg02 from './images/img.jpg';

import bgimg03 from './images/img.jpg';

import axios from 'axios';
import logo from './images/logo.jpg'

const Login = () => {

 const images = [

    bgimg01,

    bgimg02,

    bgimg03,

  // Add more image imports

 ];

 const [currentImageIndex, setCurrentImageIndex] = useState(0);

 useEffect(() => {

  const interval = setInterval(() => {

   setCurrentImageIndex((prevIndex) => (prevIndex + 1) % images.length);

  }, 3000); // Change image every 3 seconds

  return () => {

   clearInterval(interval);

  };

 }, []);

 const backgroundStyle = {

  backgroundImage: `url(${images[currentImageIndex]})`,

 };

 return (

  <div>

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

   <main className="main" style={backgroundStyle}>

    <div className="login-container">

     <h2>Login</h2>

     <Formik

      initialValues={{

       email: '',

       password: '',

      }}

      validationSchema={Yup.object({

       email: Yup.string().required('Required'),

       password: Yup.string().required('Required'),

      })}

      onSubmit={async (values) => {
        try {
          const response = await fetch('https://localhost:44326/api/Login', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify(values),
            credentials: 'include',
          });
          
          if (response.status === 200) {
            // Successful login, perform further actions (e.g., redirect, set user state)
            console.log('Logged in successfully:', await response.json());
          } else {
            // Handle other cases (e.g., invalid credentials)
            console.log('Login failed:', await response.json());
          }
        } catch (error) {
          // Handle request error
          console.error('An error occurred:', error);
        }
      }}

     >

     

<Form className="login-form">
  <div className="form-group">
    <label htmlFor="email">Email</label>
    <Field type="text" id="email" name="email" /> {/* Use "email" as the name */}
    <ErrorMessage name="email" component="div" className="error-message" />
  </div>
  <div className="form-group">
    <label htmlFor="password">Password</label>
    <Field type="password" id="password" name="password" /> {/* Use "password" as the name */}
    <ErrorMessage name="password" component="div" className="error-message" />
  </div>
  <button type="submit" className="login-button">Login</button>
</Form>

     </Formik>

     <Link to="/register" className="register-link">

     New user? Register here

    </Link>

    </div>

   </main>

  </div>

 );

};

export default Login;
