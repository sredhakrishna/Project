import React, { useState } from 'react';
import './AddParcel.css';
import logo from "./images/logo.jpg";

import { Link } from 'react-router-dom';

const AddParcel = () => {
  const [parcelDetails, setParcelDetails] = useState({
    bookingId: 0,
    description: '',
    weight: 0,
    deliveryDate: new Date().toISOString(), // Initialize with current date in ISO format
    deliveryAddress: '',
    amount: 0,
  });

  const handleChange = (event) => {
    const { name, value } = event.target;
    setParcelDetails((prevDetails) => ({
      ...prevDetails,
      [name]: value,
    }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const response = await fetch('http://localhost:7235/api/Product', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(parcelDetails),
      });

      console.log('API response status:', response.status);

      if (response.ok) {
        console.log('Parcel details submitted successfully:', parcelDetails);
      } else {
        console.error('Failed to submit parcel details');
      }
    } catch (error) {
      console.error('Error submitting parcel details:', error);
    }
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
        <h2>Add Parcel</h2>
        <form onSubmit={handleSubmit}>
          {/* ... other input fields */}
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
        <div>
          <label htmlFor="description">Description:</label>
          <input
            type="text"
            id="description"
            name="description"
            value={parcelDetails.description}
            onChange={handleChange}
          />
        </div>
        <div>
          <label htmlFor="weight">Weight (kg):</label>
          <input
            type="text"
            id="weight"
            name="weight"
            value={parcelDetails.weight}
            onChange={handleChange}
          />
        </div>
          <div>
            <label htmlFor="deliveryDate">Delivery Date:</label>
            <input
              type="datetime-local" // Use type "datetime-local" for date and time input
              id="deliveryDate"
              name="deliveryDate"
              value={parcelDetails.deliveryDate.slice(0, -1)} // Remove the trailing 'Z' character
              onChange={handleChange}
            />
          </div>
          <div>
          <label htmlFor="deliveryAddress">Delivery Address:</label>
          <input
            type="text"
            id="deliveryAddress"
            name="deliveryAddress"
            value={parcelDetails.deliveryAddress}
            onChange={handleChange}
          />
        </div>
        <div>
          <label htmlFor="amount">Amount:</label>
          <input
            type="text"
            id="amount"
            name="amount"
            value={parcelDetails.amount}
            onChange={handleChange}
          />
        </div>
          <button type="submit">Submit Parcel</button>
        </form>
      </div>
    </div>
  );
};

export default AddParcel;
