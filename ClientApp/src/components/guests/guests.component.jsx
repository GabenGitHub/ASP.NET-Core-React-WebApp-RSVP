import React from 'react';
import { connect } from 'react-redux';
import { fetchGuestList } from '../../redux/actions/guestList.actions';

class Guests extends React.Component {
    componentDidMount() {
        this.props.fetchGuestList();
    }
    
    render() {
        const guests = this.props.guests;

        let guestCounter = {
            coming: 0,
            notComing: 0
        };

        // Enums
        const isComing = Object.freeze({
            yes: "yes",
            no: "no",
            pending: ""
        });

        const iconClass = Object.freeze({
            yes: "far fa-check-circle",
            no: "far fa-times-circle",
            pending: "far fa-envelope",
            plusOne: "fas fa-user-plus"
        });

        guests.map(guest => {
            if(guest.participate === isComing.yes) {
                guestCounter.coming++;
            }
            if(guest.participate === isComing.no) {
                guestCounter.notComing++;
            }
            return guestCounter;
        });

    return(
        <div className='guests'>
            <h5>Invited ({guests.length}):</h5>
            {
                guests.map(guest => {
                    return (
                        <div key={guest._id}>
                            {
                                guest.participate === isComing.yes &&
                                <span><i className={iconClass.yes}></i></span>
                            }
                            {
                                guest.participate === isComing.no &&
                                <span><i className={iconClass.no}></i></span>
                            }
                            {
                                guest.participate === isComing.pending &&
                                <span><i className={iconClass.pending}></i></span>
                            }
                            <span> {guest.name}</span>
                        </div>
                    )
                })
                
            }
            <br/>
            <h5>Participate ({guestCounter.coming}):</h5>
            <table>
                <tbody>
                    {
                        guests.map(guest => {
                            if(guest.participate === isComing.yes) {
                                return (
                                    <tr key={guest._id}>
                                        <td>
                                            <span><i className={iconClass.yes}></i> {guest.name} </span>
                                        </td>
                                        <td>
                                            {
                                                guest.plusOne &&
                                                <span><i className={iconClass.plusOne}></i>{` ${guest.plusOneName}`}</span>
                                            }
                                        </td>
                                    </tr>
                                )
                            } else {
                                return (
                                    <tr key={ guest._id }></tr>
                                )
                            }
                        })
                    }
                </tbody>
            </table>
            <br/>
            <h5>Can't participate ({guestCounter.notComing}):</h5>
            {
                guests.map(guest => {
                    if(guest.participate === isComing.no) {
                        return (
                            <div key={guest._id}>
                                <span><i className={iconClass.no}></i></span>
                                <span> {guest.name}</span>
                            </div>)
                    } else {
                        return (
                            <div key={guest._id}></div>
                        )
                    }
                })
            }
            <br/>
            <h5>Pending respond ({guests.length - guestCounter.notComing - guestCounter.coming}):</h5>
            {
                guests.map(guest => {
                    if(guest.participate === isComing.pending) {
                        return (
                            <div key={guest._id}>
                                <span><i className={iconClass.pending}></i></span>
                                <span> {guest.name}</span>
                            </div>)
                    } else {
                        return (
                            <div key={guest._id}></div>
                        )
                    }
                })
            }
        </div>)
    }
};

const mapStateToProps = (state) => {
    return {
        guests: state.guestList.guests
    }
};

export default connect(mapStateToProps,{ fetchGuestList })(Guests);