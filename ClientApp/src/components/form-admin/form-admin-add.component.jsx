import React from 'react';
import { connect } from 'react-redux';
import { addGuest } from '../../redux/actions/guestList.actions';

class FormAdminAdd extends React.Component {
    state = {
        nameAdd: '',
    }

    checkName = async (event) => {
        const { name, value } = event.target;
        this.setState({ [name]: value });
        const respond = await fetch('/api/checkGuest', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                "name": event.target.value,
            })
        });
        if (await respond.ok) {
            const foundGuest = await respond.json()
            const { name } = foundGuest;
            this.setState({ nameRemove: name });
        }
    };

    handleChange = (event) => {
        const { name, value } = event.target;
        this.setState({ [name]: value });
    };

    handleSubmitAdd = (event) => {
        event.preventDefault();

        const guestData = {
            "name": this.state.nameAdd,
        }

        this.props.addGuest(guestData);
        this.setState({
            // Reset input from
            nameAdd: '',
        });
    };

    render() {
        return (
            <div className='admin-form-add'>
                <form onSubmit={this.handleSubmitAdd}>
                    <div>
                        <label>Invite guest </label>
                        <input
                            type="text"
                            name="nameAdd"
                            placeholder="Guest name"
                            onChange={this.handleChange}
                            value={this.state.nameAdd}
                            required
                        />
                    </div>
                    <button>Invite</button>
                </form>
            </div>
        );
    };
};

export default connect(null, { addGuest })(FormAdminAdd);