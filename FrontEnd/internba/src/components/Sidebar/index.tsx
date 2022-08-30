import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUserGroup } from "@fortawesome/free-solid-svg-icons";
import "./sidebar.scss";


function Sidebar() {
  return (
    <ul className="sidebar">
      <li>
        <span>
          <FontAwesomeIcon icon={faUserGroup} />
        </span>
        <a href="#">Hello</a>
      </li>
      <li>
        <span>
          <FontAwesomeIcon icon={faUserGroup} />
        </span>
        <a href="#">Hello</a>
      </li>
      <li>
        <span>
          <FontAwesomeIcon icon={faUserGroup} />
        </span>
        <a href="#">Hello</a>
      </li>
      <li>
        <span>
          <FontAwesomeIcon icon={faUserGroup} />
        </span>
        <a href="#">Hello</a>
      </li>
      <li>
        <span>
          <FontAwesomeIcon icon={faUserGroup} />
        </span>
        <a href="#">Hello</a>
      </li>
    </ul>
  );
}

export default Sidebar;
