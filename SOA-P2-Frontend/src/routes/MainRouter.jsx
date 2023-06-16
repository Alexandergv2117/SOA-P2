import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Employees } from "../components/employees/Employees/Employees";
import { Assets } from "../components/assets/Assets/Assets";
import { AssetsEmployees } from "../components/assetsEmployees/AssetsEmployees/AssetsEmployees";
import { Login } from "../components/login/Login";

export const MainRouter = () => {
  return (
    <div>
    < BrowserRouter>
        <Routes>
          <Route path="/" element={<Employees/>} />
          <Route path="/employees" element={<Employees/>} />
          <Route path="/assets" element={<Assets/>} />
          <Route path="/assetsEmployees" element={<AssetsEmployees/>} />
          <Route path="/login" element={<Login/>} />
          <Route path="/*" element={<Login/>} />
        </Routes>
    </ BrowserRouter>
    </div>
  )
}
