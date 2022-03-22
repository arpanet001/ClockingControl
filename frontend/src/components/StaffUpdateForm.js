import React, { useState } from "react";
import Constants from "../utilities/Constants";

export default function StaffUpdateForm(props) {
  const initialFormData = Object.freeze({
    personalFileNumber: props.staff.personalFileNumber,
    departmentId: props.staff.departmentId,
    department: props.staff.department,
    firstName: props.staff.firstName,
    lastName: props.staff.lastName,
    designation: props.staff.designation,
    registered: props.staff.registered,
    active: props.staff.active,
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

    const staffToUpdate = {
      staffId: props.staff.staffId,
      personalFileNumber: formData.personalFileNumber,
      departmentId: formData.departmentId,
      department: formData.department,
      firstName: formData.firstName,
      lastName: formData.lastName,
      designation: formData.designation,
      registered: formData.registered,
      active: formData.active,
    };
    const url = Constants.API_URL_UPDATE_STAFF;

    fetch(url, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(staffToUpdate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onStaffUpdated(staffToUpdate);
  };
  return (
    <form className="w-100 px-5">
      <h1 className="mt-5">
        Updating the Staff with Staff Id {props.staff.staffId}
      </h1>
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
        <label className="h3 form-label">Department </label>
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
        onClick={() => props.onStaffUpdated(null)}
        className="btn btn-secondary btn-lg w-100 mt-3"
      >
        Cancel
      </button>
    </form>
  );
}
