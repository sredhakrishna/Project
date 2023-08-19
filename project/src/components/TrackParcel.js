import React, { useState } from 'react';
// import './ViewParcel.css';
import './ViewParcel.css'
import logo from "./images/logo.jpg";

import { Link } from 'react-router-dom';
const TrackParcel = () => {
  const [parcelDetails, setParcelDetails] = useState({
    bookingId: '',
    
  });

  const handleChange = (event) => {
    const { name, value } = event.target;
    setParcelDetails((prevDetails) => ({
      ...prevDetails,
      [name]: value,
    }));
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    // Perform your parcel submission logic here
    console.log('Parcel details:', parcelDetails);
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
    <div className='parcel'>
      <h2>Track Parcel</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="bookingId">Booking ID:</label>
          <input
            type="text"
            id="bookingId"
            name="bookingId"
            value={parcelDetails.bookingId}
            onChange={handleChange}
          />
        </div>
        <button type="submit">Track it</button>
      </form>
    </div>
    </div>
  );
};

export default TrackParcel;
