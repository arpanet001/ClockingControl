import { render } from "@testing-library/react";
import React, { useState } from "react";

export default function IndexTime() {
  const [time, setTime] = useState([]);

  function getTime() {
    const url = `https://localhost:7218/get-all-staffs-clocking-and-clockout-time`;
    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((timesFromServer) => {
        console.log(timesFromServer);
        setTime(timesFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }
  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-center align-items-center">
          <div>
            <h1>ClockInTime and ClockOutTime</h1>

            <div className="mt-5">
              <button onClick={getTime} className="btn btn-dark btn-lg w-100">
                Get ClockInTime and ClockOutTime From Server
              </button>
            </div>
          </div>
          {renderTimesTable()}
        </div>
      </div>
    </div>
  );

  function renderTimesTable() {
    return (
      <div className="table-responsive mt-5 ">
        <table className="table table-bordered borderdark">
          <thead>
            <tr>
              <th scope="col">StaffId</th>
              <th scope="col">Personal File Number</th>
              <th scope="col">Department Id</th>
              <th scope="col">Department</th>
              <th scope="col">First Name</th>
              <th scope="col">Last Name</th>
              <th scope="col">Designation</th>
              <th scope="col">Registered</th>
              <th scope="col">Active</th>
              <th scope="col">ClockInTime</th>
              <th scope="col">ClockOutTime</th>
            </tr>
          </thead>
          <tbody>
            {time.map((time) => (
              <tr key={time.staffId}>
                <th scope="row">{time.staffId}</th>
                <td>{time.personalFileNumber}</td>
                <td>{time.departmentId}</td>
                <td>{time.department}</td>
                <td>{time.firstName}</td>
                <td>{time.lastName}</td>
                <td>{time.designation}</td>
                <td>{time.registered}</td>
                <td>{time.active}</td>
                <td>{time.clockInTime}</td>
                <td>{time.clockOutTime}</td>
              </tr>
            ))}
          </tbody>
        </table>
        <button
          onClick={() => setTime([])}
          className="btn btn-dark btn-lg w-100 "
        >
          Empty ClockInTime and ClockOutTime
        </button>
      </div>
    );
  }
}
