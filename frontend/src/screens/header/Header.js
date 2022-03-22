import React from 'react'
import Typed from 'react-typed';
import './header.css'
function Header() {
  return (
    <div className='main-info'>
      <h1>
       CLOCKING CONTROL
      </h1>
      <Typed
       strings={[
        "  ",
         "WELCOME TO CLOCKING CONTROL",
        "A PRODUCT OF THE CENTER FOR DEVELOPMENT OF ELECTRONIC DEVICES",
        "ITS FUNCTIONS INCLUDE : ",
        "ADDING A NEW STAFF TO THE SYSTEM",
        "VIEW CURRENTLY REGISTERED STAFFS",
        "VIEW TIME LOGGED IN FOR STAFF",
        "VIEW TIME LOGGED OUT FOR STAFF",
        "THANK YOU!!",
      "  ",
      "   "
                    ]}
                    typeSpeed={40}
                    backSpeed={50}
                    loop
                    />
      
    </div>
  )
}

export default Header
