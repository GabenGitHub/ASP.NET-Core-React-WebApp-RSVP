import React from 'react';
import { Link } from 'react-router-dom';
import './navbar.styles.css';

const Navbar = () => (
    <header className='navbar header'>
        <nav className='navbar-container'>
            <Link to='/' className='brand-logo'>Welcome</Link>
            <ul className="menu">
                <li className='menu-item'><Link to='/'>Home</Link></li>
                <li className='menu-item'><Link to='/admin'>Admin</Link></li>
            </ul>
        </nav>
    </header>
);

export default Navbar;