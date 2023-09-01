// place files you want to import through the `$lib` alias in this folder.
import zod from "zod";

export const COLOR = {
  Red: "Red",
  Blue: "Blue",
  Green: "Green",
} as const;

export type Color = keyof typeof COLOR;

export type Product = {
  id?: number;
  name: string;
  brand: string;
  color?: Color;
};

export const ColorToHex = (color?: Color): string => {
  switch (color) {
    case COLOR.Red:
      return "#ffcccc";
    case COLOR.Blue:
      return "#ccccff";
    case COLOR.Green:
      return "#ccffcc";
    default:
      return "#ffffff";
  }
};

export const ColorKeys = Object.keys(COLOR) as Color[];

export const ProductSchema = zod.object({
  name: zod
    .string()
    .min(1, { message: "Name must be at least 1 character long" }),
  brand: zod
    .string()
    .min(1, { message: "Brand must be at least 1 character long" }),
  color: zod.nativeEnum(COLOR, {
    errorMap: () => {
      return { message: `Color must be ${ColorKeys.join(", ")}` };
    },
  }),
  id: zod.number().optional(),
});
