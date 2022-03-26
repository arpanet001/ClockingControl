import { render } from "@testing-library/react";
import React from "react";

export default function IndexTime() {
  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-center align-items-center">
          <h1>Log In and Log Out Time</h1>
        </div>
      </div>
    </div>
  );

  function renderTimesTable() {
    render(
      <div className="table-responsive mt-5 ">
        <table className="table table-bordered borderdark">
          <thead>
            <tr>
              <th scope="col">ClockInTime</th>
              <th scope="col">ClockOutTime</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <th scope="row">1</th>
              <th>ClockInTime for Staff 1 </th>
              <th>ClockOutTime for Staff 1 </th>
            </tr>
          </tbody>
        </table>
      </div>
    );
  }
}
