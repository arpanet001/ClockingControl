import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.css";
import Constants from "../../utilities/Constants";
import StaffCreateForm from "../../components/StaffCreateForm";
import StaffUpdateForm from "../../components/StaffUpdateForm";

export default function IndexStaffs() {
  const [staffs, setStaffs] = useState([]);
  const [showingCreateNewStaffForm, setShowingCreateNewStaffForm] =
    useState(false);
  const [staffCurrentlyBeingUpdated, setStaffCurrentlyBeingUpdated] =
    useState(null);

  function getStaffs() {
    const url = Constants.API_URL_GET_ALL_STAFFS;
    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((staffsFromServer) => {
        setStaffs(staffsFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  function deleteStaff(staffId) {
    const url = `${Constants.API_URL_DELETE_STAFF_BY_ID}/${staffId}`;
    fetch(url, {
      method: "DELETE",
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
        onStaffDeleted(staffId);
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
          {showingCreateNewStaffForm === false &&
            staffCurrentlyBeingUpdated === null && (
              <div>
                <h1>New Staff Registration</h1>
                <div className="mt-5">
                  <button
                    onClick={getStaffs}
                    className="btn btn-dark btn-lg w-100"
                  >
                    Get Staff From Server
                  </button>
                  <button
                    onClick={() => setShowingCreateNewStaffForm(true)}
                    className="btn btn-secondary btn-lg w-100 mt-4"
                  >
                    Create New Staff
                  </button>
                </div>
              </div>
            )}

          {(staffs.length &&
            showingCreateNewStaffForm === false &&
            staffCurrentlyBeingUpdated === null) > 0 && renderStaffsTable()}

          {showingCreateNewStaffForm && (
            <StaffCreateForm onStaffCreated={onStaffCreated} />
          )}

          {staffCurrentlyBeingUpdated !== null && (
            <StaffUpdateForm
              staff={staffCurrentlyBeingUpdated}
              onStaffUpdated={onStaffUpdated}
            />
          )}
        </div>
      </div>
    </div>
  );

  function renderStaffsTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">StaffId(PK)</th>
              <th scope="col">PersonalFileNumber</th>
              <th scope="col">Department Id</th>
              <th scope="col">Department</th>
              <th scope="col">FirstName</th>
              <th scope="col">LastName</th>
              <th scope="col">Designation</th>
              <th scope="col">Registered</th>
              <th scope="col">Active</th>
            </tr>
          </thead>
          <tbody>
            {staffs.map((staff) => (
              <tr key={staff.staffId}>
                <td>{staff.staffId}</td>
                <td>{staff.personalFileNumber}</td>
                <td>{staff.departmentId}</td>
                <td>{staff.department}</td>
                <td>{staff.firstName}</td>
                <td>{staff.lastName}</td>
                <td>{staff.designation}</td>
                <td>{staff.registered}</td>
                <td>{staff.active}</td>
                <td>
                  <button
                    onClick={() => setStaffCurrentlyBeingUpdated(staff)}
                    className="btn btn-dark btn-lg mx-3 my-3"
                  >
                    Update
                  </button>
                  <button
                    onClick={() => {
                      if (
                        window.confirm(
                          `Are you sure you want to delete the Staff with Staff Id"${staff.staffId}"?`
                        )
                      )
                        deleteStaff(staff.staffId);
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
          onClick={() => setStaffs([])}
          className="btn btn-dark btn-lg w-100"
        >
          Empty Staff
        </button>
      </div>
    );
  }

  function onStaffCreated(createdStaff) {
    setShowingCreateNewStaffForm(false);
    if (createdStaff === null) {
      return;
    }

    alert(
      `Staff successfully created after clicking Ok,your new staff with staffId"${createdStaff.staffId}" will show up in the table below`
    );
    getStaffs();
  }

  function onStaffUpdated(updatedStaff) {
    setStaffCurrentlyBeingUpdated(null);

    if (updatedStaff === null) {
      return;
    }
    let staffsCopy = [...staffs];
    const index = staffsCopy.findIndex((staffsCopyStaff, currentIndex) => {
      if (staffsCopyStaff.staffId === updatedStaff.staffId) {
        return true;
      }
    });
    if (index !== -1) {
      staffsCopy[index] = updatedStaff;
    }
    setStaffs(staffsCopy);
    alert(
      `Staff Successfully Updated.After clicking OK,look for the staff with Staff Id "${updatedStaff.staffId}" in the Table below to see updates`
    );
  }

  function onStaffDeleted(deletedStaffStaffId) {
    let staffsCopy = [...staffs];
    const index = staffsCopy.findIndex((staffsCopyStaff, currentIndex) => {
      if (staffsCopyStaff.staffId === deletedStaffStaffId) {
        return true;
      }
    });
    if (index !== -1) {
      staffsCopy.splice(index, 1);
    }
    setStaffs(staffsCopy);
    alert(
      "Staff Successfully Deleted.After Clicking OK. Look at the table below to see your Staff dissapear."
    );
  }
}
