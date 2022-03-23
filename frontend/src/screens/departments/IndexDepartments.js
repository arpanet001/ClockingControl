import React, { useState } from "react";
import Constants from "../../utilities/Constants";

export default function IndexDepartments() {
  const [departments, setDepartments] = useState([]);

  function getDepartments() {
    const url = Constants.API_URL_GET_ALL_DEPARTMENTS;
    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((departmentsFromServer) => {
        console.log(departmentsFromServer);
        setDepartments(departmentsFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div>
            <h1>New Department Registration</h1>
            <div className="mt-5">
              <button
                onClick={getDepartments}
                className="btn btn-dark btn-lg w-100"
              >
                Get Departments From Server
              </button>

              <button
                onClick={() => {}}
                className="btn btn-secondary btn-lg w-100 mt-4"
              >
                Create New Department
              </button>
            </div>
          </div>
          {departments.length > 0 && renderDepartmentsTable()}
        </div>
      </div>
    </div>
  );

  function renderDepartmentsTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">DepartmentId(PK)</th>
              <th scope="col">DepartmentName</th>
            </tr>
          </thead>
          <tbody>
            {departments.map((department) => (
              <tr key={department.departmentId}>
                <th scope="row">{department.departmentId}</th>
                <td>{department.departmentName}</td>
                <td>
                  <button className="btn btn-dark btn-lg mx-3 my-3">
                    Update
                  </button>
                  <button className="btn btn-secondary btn-lg">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <button
          onClick={() => setDepartments([])}
          className="btn btn-dark btn-lg w-100"
        >
          Empty Departments
        </button>
      </div>
    );
  }
}
