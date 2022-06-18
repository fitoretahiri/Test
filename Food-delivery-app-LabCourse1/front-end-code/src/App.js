import React from 'react';
import './App.css';
import { useEffect, useState } from "react";

import { Restoranti } from './Restoranti';
import { Qyteti } from './Qyteti';
import { Menu } from './Menu';
import { Roli } from './Roli';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import LoginForm from './LoginForm';
import TransportuesiRegister from './TransportuesiRegister';
import RestorantiRegister from './RestorantiRegister';
import KlientiRegister from './KlientiRegister';
import { Restaurant_Qyteti } from './Restaurant_Qyteti';
import { Perdoruesi } from './Perdoruesi';
import DashboardRestoranti from './DashboardRestoranti';
import AppNavbar from './AppNavbar';



function App() {
    const [name, setName] = useState('');
    useEffect(()=>{
        (
            async () => {
                const response = await fetch(process.env.REACT_APP_API+'authmanagement/user',{
                    headers:{
                        'Accept':'application/json',
                        'Content-Type':'application/json'
                    },
                    credentials: 'include'
                });

                const content = await response.json();
                setName(content.userName);
            }
        )()
    }, [name]);
    
    
    return (
        <Router>
            <div className="App container">
                <AppNavbar name={name} setName={setName}/>
                    <Switch>
                    <Route path="/restaurant" component={Restoranti} />
                    <Route path="/qyteti" component={Qyteti} />
                    <Route path="/menu" component={Menu} />
                    <Route path="/role" component={Roli} />
                    <Route path="/restaurant_qyteti" component={Restaurant_Qyteti} />
                    <Route exact path="/" component={() => <LoginForm setName={setName}/>} />
                    <Route exact path="perdoruesi" component={Perdoruesi} />
                    <Route path="/klientiregister" component={KlientiRegister} />
                    <Route path="/transportuesiregister" component={TransportuesiRegister} />
                    <Route path="/restorantiregister" component={RestorantiRegister} />
                    <Route path="/restorantidashboard" component={() => <DashboardRestoranti name={name}/>} />
                    </Switch>
            </div>
        </Router>
    );
}

export default App;

