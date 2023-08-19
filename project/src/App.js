import React from 'react';


import { BrowserRouter,Routes, Route } from 'react-router-dom';



import Login from './components/Login.js';



import './components/Homepage.css';
import Homepage from './components/HomePage.js';
import UserRegister from './components/UserRegister.js';
import AddParcel from './components/AddParcel.js';
import ViewParcel from './components/ViewParcel.js';
import TrackParcel from './components/TrackParcel.js';
import AboutUs from './components/About Us.js';

function App() {

 return (
  <BrowserRouter>
   <Routes>

    <Route path="/" element={<Homepage />} />

   

    <Route path="/login" element={<Login />} />
    <Route path="/register" element={<UserRegister />} />
    <Route path="/addParcel" element={<AddParcel />} />
    <Route path="/viewParcel" element={<ViewParcel />} />
    <Route path="/trackParcel" element={<TrackParcel />} />
    <Route path="/aboutUs" element={<AboutUs />} />

   </Routes>
   
   </BrowserRouter>

 );

}

export default App;