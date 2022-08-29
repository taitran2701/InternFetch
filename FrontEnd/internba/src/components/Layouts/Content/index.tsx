import { Container } from "react-bootstrap"
import Dropdown from 'react-bootstrap/Dropdown';

import "./content.scss"
function Content(){
    return (
        <>
        <Container>
            <div className="headcontent">
                <p>Content title</p>
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
            </div>
        </Container>
        </>
    )
    
   
}
export default Content;