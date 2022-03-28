import "./App.css";
import Navigation from "./screens/navigationbar/NavigationBar";
import Particles from "./Particles";
import Header from "./screens/header/Header";
import IndexStaffs from "./screens/staffs/IndexStaffs";
import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import IndexDepartments from "./screens/departments/IndexDepartments";
import IndexTime from "./screens/time/IndexTime";

function App() {
  return (
    <Router>
      <div>
        {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
        <Switch>
          <Route path="/home">
            <Header />
            <Navigation />
            <Particles />
          </Route>
          <Route path="/staff">
            <IndexStaffs />
          </Route>
          <Route path="/department">
            <IndexDepartments />
          </Route>
          <Route path="/time">
            <IndexTime />
          </Route>
          <Route path="/contact"></Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
