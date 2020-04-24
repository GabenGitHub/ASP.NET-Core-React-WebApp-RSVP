import React from 'react';
import { connect } from 'react-redux';
import { removeGuest } from '../../redux/actions/guestList.actions';

class FormAdminRemove extends React.Component {
    state = {
        nameRemove: '',
        message: '',
        isOnTheList: false
    }

    checkName = async (event) => {
        const { name, value } = event.target;
        this.setState({ [name]: value });
        const respond = await fetch('/api/guests/check', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                "name": event.target.value,
            })
        });
        if (await respond.ok) {
            const foundGuest = await respond.json()
            const { name } = foundGuest;
            this.setState({ 
                nameRemove: name, 
                message: 'Found',
                isOnTheList: true
            });
        } else {
            this.setState({ 
                isOnTheList: false,
                message: await respond.text() 
            })
        }
    };

    handleChange = (event) => {
        const { name, value } = event.target;
        this.setState({ [name]: value });
    };

    handleSubmitRemove = (event) => {
        event.preventDefault();

        const guestData = {
            "name": this.state.nameRemove,
        }

        this.props.removeGuest(guestData);
        this.setState({
            // Reset input from
            nameRemove: '',
            message: '',
            isOnTheList: false
        });
    };

    render() {
        return (
            <div className='admin-form-remove'>
                <form onSubmit={this.handleSubmitRemove}>
                    <div>
                        <label>Remove guest </label>
                        <input
                            type="text"
                            name='nameRemove'
                            placeholder='Guest name'
                            onChange={this.checkName}
                            value={this.state.nameRemove}
                            required
                        />
                        <span> {this.state.message}</span>
                    </div>
                    {
                        this.state.isOnTheList &&
                            <button>Remove</button>
                    }
                </form>
            </div>
        );
    };
};


export default connect(null, { removeGuest })(FormAdminRemove);