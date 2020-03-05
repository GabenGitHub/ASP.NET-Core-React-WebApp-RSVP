import React from 'react';
// import './home.styles.css'

import About from '../about/about.component';
import Guests from '../guests/guests.component';
import FormInput from '../form-input/form-input.component';

const Home = () => {
    return (
        <div className="main">
            <About />
            <FormInput />
            <Guests />
        </div>
    )
};

export default Home;