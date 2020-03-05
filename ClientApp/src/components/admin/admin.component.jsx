import React from 'react';

import Guests from '../guests/guests.component';
import FormAdminAdd from '../form-admin/form-admin-add.component';
import FormAdminRemove from '../form-admin/form-admin-remove.component';

const Admin = () => {
    return (
        <div className="main admin">
            <div className='about'>
                <h2>Admin form</h2>
                <p>Here you can manage the participants</p>
            </div>
            
            <FormAdminAdd />
            <FormAdminRemove />
            <Guests />
        </div>
    )
};

export default Admin;