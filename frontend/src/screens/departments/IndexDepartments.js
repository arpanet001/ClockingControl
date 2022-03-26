import React, { useState } from "react";
import Constants from "../../utilities/Constants";
import DepartmentCreateForm from "../../components/DepartmentCreateForm";
import DepartmentUpdateForm from "../../components/DepartmentUpdateForm";

export default function IndexDepartments() {
  const [departments, setDepartments] = useState([]);
  const [showingCreateNewDepartmentForm, setShowingCreateNewDepartmentForm] =
    useState(false);
  const [departmentCurrentlyBeingUpdated, setDepartmentCurrentlyBeingUpdated] =
    useState(null);

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

  function deleteDepartment(departmentId) {
    const url = `${Constants.API_URL_DELETE_DEPARTMENT_BY_ID}/${departmentId}`;

    fetch(url, {
      method: "DELETE",
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
        console.log(responseFromServer);
        onDepartmentDeleted(departmentId);
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
          {showingCreateNewDepartmentForm === false &&
            departmentCurrentlyBeingUpdated === null && (
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
                    onClick={() => setShowingCreateNewDepartmentForm(true)}
                    className="btn btn-secondary btn-lg w-100 mt-4"
                  >
                    Create New Department
                  </button>
                </div>
              </div>
            )}

          {departments.length > 0 &&
            showingCreateNewDepartmentForm === false &&
            departmentCurrentlyBeingUpdated === null &&
            renderDepartmentsTable()}
          {showingCreateNewDepartmentForm && (
            <DepartmentCreateForm onDepartmentCreated={onDepartmentCreated} />
          )}

          {departmentCurrentlyBeingUpdated !== null && (
            <DepartmentUpdateForm
              department={departmentCurrentlyBeingUpdated}
              onDepartmentUpdated={onDepartmentDeleted}
            />
          )}
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
                  <button
                    onClick={() =>
                      setDepartmentCurrentlyBeingUpdated(department)
                    }
                    className="btn btn-dark btn-lg mx-3 my-3"
                  >
                    Update
                  </button>
                  <button
                    onClick={() => {
                      if (
                        window.confirm(`Are you sure you want to delete the department
                    with department name "${department.departmentName}"?`)
                      )
                        deleteDepartment(department.departmentId);
                    }}
                    className="btn btn-secondary btn-lg"
                  >
                    Delete
                  </button>
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

  function onDepartmentCreated(createdDepartment) {
    setShowingCreateNewDepartmentForm(false);

    if (createdDepartment === null) {
      return;
    }
    alert(`Department Successfully Created.`);
    getDepartments();
  }

  function onDepartmentDeleted(updatedDepartment) {
    setDepartmentCurrentlyBeingUpdated(null);
    if (updatedDepartment === null) {
      return;
    }

    let departmentsCopy = [...departments];
    const index = departmentsCopy.findIndex(
      (departmentsCopyDepartment, currentIndex) => {
        if (
          departmentsCopyDepartment.departmentId ===
          updatedDepartment.departmentId
        ) {
          return true;
        }
      }
    );
    if (index !== -1) {
      departmentsCopy[index] = updatedDepartment;
    }
    setDepartments(departmentsCopy);
    alert(
      `Department successfully updated.After clicking OK, look fro the department with the depaertment name "${updatedDepartment.departmentName}" in the table below to see the updates`
    );
  }

  function onDepartmentDeleted(deletedDepartmentDepartmentId) {
    let departmentsCopy = [...departments];
    const index = departmentsCopy.findIndex(
      (departmentsCopyDepartment, currentIndex) => {
        if (
          departmentsCopyDepartment.departmentId ===
          deletedDepartmentDepartmentId
        ) {
          return true;
        }
      }
    );
    if (index !== -1) {
      departmentsCopy.splice(index, 1);
    }
    setDepartments(departmentsCopy);
    alert(
      "Department successfully deleted. After clicking OK,look at the table below to see the department disappear "
    );
  }
}
