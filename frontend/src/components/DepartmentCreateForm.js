import React, { useState } from "react";
import Constants from "../utilities/Constants";

export default function DepartmentCreateForm() {
  return (
    <div>
      <form className="w-100 px-5">
        <h1 className="mt-5">Create New Department</h1>
        <div className="mt-5">
          <label className="h3 form-label ">Department Name</label>
          <input
            value={formData.departmentName}
            name="departmentName"
            type="text"
            className="form-control"
            onChange={handleChange}
          ></input>
        </div>
      </form>
    </div>
  );
}
