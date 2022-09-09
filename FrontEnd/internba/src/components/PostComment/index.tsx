import React, { useEffect, useState } from "react";
import styles from "./index.module.scss";

interface IComment {
  id: string;
  content: string;
  userId: string;
  postId: string;
}

interface IPost {
  postComment: {
    id: string;
    content: string;
  };
}

function UpComment(props: IPost) {
  const [comments, setComments] = useState([]);
  const [postId, setPostId] = useState<string>("");
}
export default UpComment;
