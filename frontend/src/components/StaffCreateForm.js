import React, { useState } from "react";
import Constants from "../utilities/Constants";

export default function StaffCreateForm(props) {
  const initialFormData = Object.freeze({
    personalFileNumber: "Input staff's personal file number",
    departmentId: "Input staff's department Id",
    department: "Input staff's department",
    firstName: "Input staff's firstName",
    lastName: "Input staff's lastName",
    designation: "Input staff's designation",
    registered: "Is the staff registered?",
    active: "is the staff active?",
  });

  const [formData, setFormData] = useState(initialFormData);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const staffToCreate = {
      staffId: 0,
      personalfilenumber: formData.personalFileNumber,
      departmentId: formData.departmentId,
      department: formData.department,
      firstName: formData.firstName,
      lastName: formData.lastName,
      designation: formData.designation,
      registered: formData.registered,
      active: formData.active,
    };
    const url = Constants.API_URL_CREATE_STAFF;

    fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(staffToCreate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onStaffCreated(staffToCreate);
  };
  return (
    <form className="w-100 px-5">
      <h1 className="mt-5">Create New Staff</h1>
      <div className="mt-5">
        <label className="h3 form-label">Personal File Number</label>
        <input
          value={formData.personalFileNumber}
          name="personalFileNumber"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-5">
        <label className="h3 form-label">Department Id</label>
        <input
          value={formData.departmentId}
          name="departmentId"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-5">
        <label className="h3 form-label">Department</label>
        <input
          value={formData.department}
          name="department"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-4">
        <label className="h3 form-label">FirstName</label>
        <input
          value={formData.firstName}
          name="firstName"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-4">
        <label className="h3 form-label">LastName</label>
        <input
          value={formData.lastName}
          name="lastName"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-4">
        <label className="h3 form-label">Designation</label>
        <input
          value={formData.designation}
          name="designation"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-4">
        <label className="h3 form-label">Registered</label>
        <input
          value={formData.registered}
          name="registered"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <div className="mt-4">
        <label className="h3 form-label">Active</label>
        <input
          value={formData.active}
          name="active"
          type="text"
          className="form-control"
          onChange={handleChange}
        />
      </div>

      <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">
        Submit
      </button>

      <button
        onClick={() => props.onUserCreated(null)}
        className="btn btn-secondary btn-lg w-100 mt-3"
      >
        Cancel
      </button>
    </form>
  );
}
