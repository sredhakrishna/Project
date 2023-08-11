import React from 'react';
import './Page.css';
import Sidebar from './Sidebar';
import delv from './delv.jpg';

function Page() {
  return (
    <div>
      <div className="topnav">
        <div className="title">DellivNow</div>
        <div className="topnav-links">
          <a className="active" href="#home">Home</a>
          <a href="#login">Login</a>
          <div className="dropdown">
            <button className="dropbtn">Services</button>
            <div className="dropdown-content">
              <a href="#view-parcel-list">View Parcel List</a>
              <a href="#track-parcel-list">Track Parcel List</a>
            </div>
          </div>
          <a href="#faq">FAQ</a>
          <a href="#AboutUs">About Us</a>
          <a href="#About">About</a>
        </div>
      </div>
      <div className="container">
        <div className="slider">
          <img src={delv} alt="DellivNow" />
        </div>
        <div className="form-container">
          <div className="box">
            <form>
              <h1>Track your parcel</h1>
              <div className="input-container">
                <label htmlFor="bookingId">Booking ID</label>
                <input type="text" id="bookingId" placeholder="" />
              </div>
              <div className="submit-container">
                <button type="submit">Submit</button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Page;
