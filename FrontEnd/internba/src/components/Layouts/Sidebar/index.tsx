import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUserGroup } from "@fortawesome/free-solid-svg-icons";
import "./sidebar.scss";

function Siderbar() {
  return (
    <ul>
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

export default Siderbar;
