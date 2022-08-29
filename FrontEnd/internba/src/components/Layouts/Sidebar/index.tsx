import Dropdown from 'react-bootstrap/Dropdown';
import "./sidebar.scss";



function Siderbar(){
    return (
        <>
            <ul>
                <li>
                    
                    <div> 
                        <p>Avatar</p>
                    </div>
                </li>
                <li>
                    <div> Ban be</div>
                </li>
                <li>
                    <div>Nhom</div>
                </li>
                <li>
                    <div>Marketplace</div>
                </li>
                <li>
                    <div>Watch</div>
                </li>
                <li>
                    <div> Ki niem</div>
                </li>
            </ul>
            <Dropdown>
                <Dropdown.Toggle variant="primary" id="dropdown-basic">
                    Xem them
                </Dropdown.Toggle>

                <Dropdown.Menu>
                    <Dropdown.Item href="#/action-1">Action</Dropdown.Item>
                    <Dropdown.Item href="#/action-2">Another action</Dropdown.Item>
                    <Dropdown.Item href="#/action-3">Something else</Dropdown.Item>
                </Dropdown.Menu>
    </Dropdown>
        </>
    )
}

export default Siderbar;