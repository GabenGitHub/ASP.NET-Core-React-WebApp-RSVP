import React from 'react';
import './App.css'
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import Navbar from './components/navbar/navbar.component';
import Home from './components/home/home.component';
import Admin from './components/admin/admin.component';
import Footer from './components/footer/footer.component';

class App extends React.Component {
    render() {
        return (
            <div className='grid-container'>
                <BrowserRouter>
                    <Navbar />
                    <Switch>
                        <Route exact path='/'>
                            <Home />
                        </Route>
                        <Route path='/admin'>
                            <Admin />
                        </Route>
                    </Switch>
                    <Footer />
                </BrowserRouter>
            </div>
        );
    };
};

export default App;
