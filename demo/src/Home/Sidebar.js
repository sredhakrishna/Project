import React from 'react';
import './Page.css';

function Sidebar() {
  return (
    <div>
      <div className="sidebar">
        <ul>
          <li><div className="sidebar-element"><a href="#">Profile</a></div></li>
          <li><div className="sidebar-element"><a href="#">Notification</a></div></li>
          <li><div className="sidebar-element"><a href="#">Tools</a></div></li>
        </ul>
      </div>
    </div>
  );
}

export default Sidebar;
