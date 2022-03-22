import { Component } from "react";
import Header from "./screens/header/Header";
import IndexUsers from "./screens/users/IndexUsers";


const routes =[ 
 {path:'/users',component:IndexUsers,exact:true},
];
export default routes;
