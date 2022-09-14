import { Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar";
import './App.scss';
import './App.css';
import ViewRecord from "./components/ViewRecord";
import GraphRecord from "./components/GraphRecord";
function App() {
  //const  tranInsert= useSelector((state)=>state)
  return (
    <div className="App">
      <Navbar ></Navbar>
      <Routes>
        <Route path='/' exact element={<ViewRecord />}/>
         <Route path='/view' element={<ViewRecord />} />
         <Route path='/posted' exact element={<GraphRecord />} />  
      </Routes>
    </div>
  );
}

export default App;
