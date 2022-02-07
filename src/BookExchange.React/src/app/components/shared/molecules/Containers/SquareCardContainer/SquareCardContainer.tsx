import { CardActionArea, CardActions, Button } from "@mui/material";
import { ImageUtils } from "@utils/image.utils";
import { ReactNode } from "react";
import { CardRoot, Media, CardContentSquare } from "./SquareCardContainer.styled";

interface ISquareCardContainerProps {
  action?: () => void;
  actionText?: string;
  imagePath: string | undefined;
  children: ReactNode;
}

const SquareCardContainer = ({
 action,
 actionText,
 imagePath,
 children,
}: ISquareCardContainerProps) => {
  return (
    <CardRoot>
      <CardActionArea>
        {imagePath && (
          <Media
            image={ImageUtils.getAbsolutePath(imagePath)}
            title="Contemplative Reptile"
          />
        )}

        <CardContentSquare>{children}</CardContentSquare>
      </CardActionArea>
      <CardActions>
        {action && actionText && (
          <Button
            variant="outlined"
            color="secondary"
            size="small"
            onClick={action}
          >
            {actionText}
          </Button>
        )}
      </CardActions>
    </CardRoot>
  );
};

export { SquareCardContainer };